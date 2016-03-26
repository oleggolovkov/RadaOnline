using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace RadaOnline.Parsers.Tests {
    [TestClass]
    public class CsvParserTests {
        [TestMethod]
        public void Session_9() {
            var reader = new StreamReader("Data\\Поіменні голосування БМР - 9 сесія.csv");
            var parser = new CsvParser();
            var session = parser.Parse(reader);

            //session properties
            Assert.IsNotNull(session);
            Assert.AreEqual(9, session.Number);
            Assert.IsFalse(session.IsRegular);


            //session items
            Assert.AreEqual(5, session.SessionItems.Count);
            string[] expectedTitles = {
                "Порядок",
                "прийняття",
                "співфінансування",
                "культури",
                "Заслуховування"
            };
            var titles = string.Join("", session.SessionItems.Select(si => si.Title));
            Assert.IsTrue(expectedTitles.All(t => titles.Contains(t)));
            var sessionItems = session.SessionItems.ToArray();
            Assert.AreEqual(Database.Models.Enums.SessionItemStatus.Accepted, sessionItems[0].Status);
            Assert.AreEqual(Database.Models.Enums.SessionItemStatus.Rejected, sessionItems[1].Status);
            Assert.AreEqual(Database.Models.Enums.SessionItemStatus.Accepted, sessionItems[2].Status);
            Assert.AreEqual(Database.Models.Enums.SessionItemStatus.Rejected, sessionItems[3].Status);
            Assert.AreEqual(Database.Models.Enums.SessionItemStatus.Accepted, sessionItems[4].Status);


            //decisions
            var decisions = session.SessionItems.SelectMany(si => si.Decisions).ToArray();
            Assert.AreEqual(12, decisions.Length);
            string[] expectedDescriptions = {
                "Порядок",
                "Внесення",
                "денний",
                "прийняття",
                "рішення",
                "співфінансування",
                "проекту",
                "культури",
                "Заслухавши",
                "Заслуховування",
                "молоді",
                "начальника",
            };
            var descriptions = string.Join("", session.SessionItems.SelectMany(si => si.Decisions).Select(d=>d.Description));
            Assert.IsTrue(expectedDescriptions.All(d => descriptions.Contains(d)));
            Assert.IsTrue(decisions[0].IsAccepted);
            Assert.IsFalse(decisions[1].IsAccepted);
            Assert.IsTrue(decisions[2].IsAccepted);
            Assert.IsTrue(decisions[3].IsAccepted);
            Assert.IsFalse(decisions[4].IsAccepted);
            Assert.IsTrue(decisions[5].IsAccepted);
            Assert.IsTrue(decisions[6].IsAccepted);
            Assert.IsTrue(decisions[7].IsAccepted);
            Assert.IsFalse(decisions[8].IsAccepted);
            Assert.IsFalse(decisions[9].IsAccepted);
            Assert.IsTrue(decisions[10].IsAccepted);
            Assert.IsTrue(decisions[11].IsAccepted);
            
            Assert.AreEqual(Database.Models.Enums.DecitionType.Base, decisions[0].Type);
            Assert.AreEqual(Database.Models.Enums.DecitionType.Changes, decisions[1].Type);
            Assert.AreEqual(Database.Models.Enums.DecitionType.Final, decisions[2].Type);
            Assert.AreEqual(Database.Models.Enums.DecitionType.Base, decisions[3].Type);
            Assert.AreEqual(Database.Models.Enums.DecitionType.Final, decisions[4].Type);
            Assert.AreEqual(Database.Models.Enums.DecitionType.Base, decisions[5].Type);
            Assert.AreEqual(Database.Models.Enums.DecitionType.Final, decisions[6].Type);
            Assert.AreEqual(Database.Models.Enums.DecitionType.Base, decisions[7].Type);
            Assert.AreEqual(Database.Models.Enums.DecitionType.Changes, decisions[8].Type);
            Assert.AreEqual(Database.Models.Enums.DecitionType.Final, decisions[9].Type);
            Assert.AreEqual(Database.Models.Enums.DecitionType.Base, decisions[10].Type);
            Assert.AreEqual(Database.Models.Enums.DecitionType.Final, decisions[11].Type);


            //votes
            var votes = decisions[0].Votes.ToArray();
            Assert.AreEqual(37, votes.Length);
            var pro = votes.Where(v => v.Type == Database.Models.Enums.VoteType.Pro).Count();
            Assert.AreEqual(30,pro);
            var contra = votes.Where(v => v.Type == Database.Models.Enums.VoteType.Contra).Count();
            Assert.AreEqual(3, contra);
            votes = decisions[11].Votes.ToArray();
            Assert.AreEqual(37, votes.Length);
            pro = votes.Where(v => v.Type == Database.Models.Enums.VoteType.Pro).Count();
            Assert.AreEqual(28, pro);
            contra = votes.Where(v => v.Type == Database.Models.Enums.VoteType.Contra).Count();
            Assert.AreEqual(0, contra);


            //votes by name
            votes = decisions.Select(d => d.Votes.First()).ToArray();// SPZH votes
            Assert.AreEqual(Database.Models.Enums.VoteType.Pro, votes[0].Type);
            Assert.AreEqual(Database.Models.Enums.VoteType.Contra, votes[1].Type);
            Assert.AreEqual(Database.Models.Enums.VoteType.Pro, votes[2].Type);
            Assert.AreEqual(Database.Models.Enums.VoteType.Pro, votes[3].Type);
            Assert.AreEqual(Database.Models.Enums.VoteType.Contra, votes[4].Type);
            Assert.AreEqual(Database.Models.Enums.VoteType.Pro, votes[5].Type);
            Assert.AreEqual(Database.Models.Enums.VoteType.Pro, votes[6].Type);
            Assert.AreEqual(Database.Models.Enums.VoteType.Pro, votes[7].Type);
            Assert.AreEqual(Database.Models.Enums.VoteType.Neutral, votes[8].Type);
            Assert.AreEqual(Database.Models.Enums.VoteType.Pro, votes[9].Type);
            Assert.AreEqual(Database.Models.Enums.VoteType.Pro, votes[10].Type);
            Assert.AreEqual(Database.Models.Enums.VoteType.Pro, votes[11].Type);
        }
    }
}
