# RadaOnline
The purpose of this project is to collect information about voting in local councils and to provide public REST API to access this information

## Entities
- **Council**
- **Fraction** - group of the councilmen
- **Councilman**
- **Session** - meeting where councilmen take decisions
- **Session Item** - item of the agenda of the session, each session item can have few decisions (take as the basis, apply changes, final decistion)
- **Decision** - it's voting process with exact result (accepted or not)
- **Vote** - voting of single councilman for the decision

## Resources and Actions
|Url|Method|Optional params|Operation|
|---|---|---|---|
|/api/councils|GET|name, take, skip|List of councils|
|/api/councils/:id|GET||Deails of the council|
|/api/councils/:id/councilmen|GET|fractionid, name, take, skip|List of councilmen of the council|
|/api/councils/:id/fractions|GET|name, take, skip|List of fractions of the council|
|/api/councilmen/:id|GET||Deails of the councilman|
|/api/fractions/:id|GET||Deails of the fraction|

## Dependencies
- ASP.NET WebApi 2
- Entity Framework Code First 6
- Ninject
- Log4Net