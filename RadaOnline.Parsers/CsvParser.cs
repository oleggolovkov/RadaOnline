using RadaOnline.Database.Models;
using RadaOnline.Database.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadaOnline.Parsers {

    public class CsvParser {
        private const int INVALID_VALUE = -1;
        private const int VOTES_FOR_ACCEPTANCE = 19;
        private Councilman[] councilmen;
        private Councilman GetCouncilmenById(int id) { //should be replaced with real implementation
            return councilmen.First(c => c.Id == id);
        }

        public Session Parse(TextReader reader) {
            var session = new Session { SessionItems = new List<SessionItem>()};
            var title = reader.ReadLine().Trim(',');//first line
            session.IsRegular = GetIsRegular(title);
            session.Number = GetNumberFromString(title);
            reader.ReadLine();//should be an empty string
            var headers = reader.ReadLine().Split(',');//№ рішення,Проект рішення, Зареєстр., Відсутні, За, Проти, Утрим., Не голос.,М.г.Сапожко І.В.,Секр.Здоровець О.М., ... all other councilmen                      

            //---next block adds demo councilmen. They should be fetched from db 
            var councilmanId = 0;
            councilmen = headers.Skip(8).Select(name => new Councilman { FullName = name, Id = councilmanId++}).ToArray();

            var columnsCount = 45; //table should contain 45 columns
            string sessionItemStr = null;
            SessionItem sessionItem = null;
            while ((sessionItemStr = reader.ReadLine()) != null) {
                var subStrings = sessionItemStr.Split(',');
                var subStringsCount = subStrings.Length;
                int number = INVALID_VALUE;
                var descriptionColumnSpan = subStringsCount - columnsCount + 1; //description can contain commas, this is an easy hack to determine its width   
                var description = string.Join(",", subStrings.Skip(1).Take(descriptionColumnSpan)).Trim('\"');
                if (sessionItem==null ||  int.TryParse(subStrings[0], out number)) { //new session item
                    sessionItem = new SessionItem { Decisions = new List<Decision>(), Title = description.Replace("за основу", "")};                    
                    sessionItem.Number = number;                    
                    session.SessionItems.Add(sessionItem);
                }
                var decision = new Decision { Votes = new List<Vote>() };
                decision.Description = description;
                decision.Type = GetDecisionType(description);
                subStrings = subStrings.Skip(1 + descriptionColumnSpan).ToArray();//move to next fields
                var registered = GetNumberFromString(subStrings[0]);
                var absent = GetNumberFromString(subStrings[1]);
                var pro = GetNumberFromString(subStrings[2]);
                var contra = GetNumberFromString(subStrings[3]);
                var neutral = GetNumberFromString(subStrings[4]);
                var didNotVote = GetNumberFromString(subStrings[5]);
                decision.IsAccepted = pro >= VOTES_FOR_ACCEPTANCE;
                if (decision.Type == DecitionType.Final) {
                    sessionItem.Status = decision.IsAccepted ? SessionItemStatus.Accepted : SessionItemStatus.Rejected;
                }        
                for (int i = 0; i < 37; i++) {
                    var vote = new Vote();
                    vote.Type = GetVoteType(subStrings[i + 6]); //councilmen start from position '6' in an adjusted array
                    vote.Councilman = GetCouncilmenById(i);
                    decision.Votes.Add(vote);
                }
                sessionItem.Decisions.Add(decision);}
            return session;
        }

        private int GetNumberFromString(string s) {
            int number;
            var numberStr = new string(s.Where(char.IsDigit).ToArray());
            return int.TryParse(numberStr, out number) ? number : INVALID_VALUE;
        }

        private bool GetIsRegular(string sessionTitle) {
            return !sessionTitle.Contains("позачергова");
        }

        private DecitionType GetDecisionType(string description) {
            description = description.ToLower();
            if (description.EndsWith("за основу"))
                return DecitionType.Base;
            if (description.EndsWith("в цілому"))
                return DecitionType.Final;
            return DecitionType.Changes;
        }

        private VoteType GetVoteType(string voteString) {
            if (voteString == "за")
                return VoteType.Pro;
            if (voteString == "проти")
                return VoteType.Contra;
            if (voteString == "утр.")
                return VoteType.Neutral;
            return VoteType.Neutral; //I guess we should add something for 'did not vote'?
        }
    }
}
