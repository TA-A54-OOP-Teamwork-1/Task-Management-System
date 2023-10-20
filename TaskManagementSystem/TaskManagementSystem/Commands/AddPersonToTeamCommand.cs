using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands
{
    public class AddPersonToTeamCommand : BaseCommand
    {
        private const string PersonAlreadyMemeberOfTeamErrorMessage = "Person {0} is already a member of team {1}!";

        private const int ExpectedParametersCount = 2;

        public AddPersonToTeamCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var personName = base.Parameters[0];
            var teamName = base.Parameters[1];
            var person = base.Repository.GetPersonByName(personName);
            var team = base.Repository.GetTeamByName(teamName);

            // Do not allow adding person to team if it's already a member
            if (team.People.Contains(person))
            {
                throw new NotAllowedException(string.Format(PersonAlreadyMemeberOfTeamErrorMessage, personName, teamName));
            }
            
            team.AddPerson(person);

            return $"Person with name {personName} added to team {teamName}";
        }
    }
}
