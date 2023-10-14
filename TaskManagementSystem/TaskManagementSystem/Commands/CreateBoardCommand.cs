﻿using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Exceptions;

namespace TaskManagementSystem.Commands
{
    public class CreateBoardCommand : BaseCommand
    {
        private const string BoardAlreadyExistsErrorMessage = "Board with name {0} already exists!";

        private const int ExpectedParametersCount = 2;

        public CreateBoardCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            base.ValidateParametersCount(ExpectedParametersCount);

            var boardName = Parameters[0];
            var teamName = Parameters[1];

            if (base.Repository.BoardExists(boardName))
            {
                throw new InvalidUserInputException(string.Format(BoardAlreadyExistsErrorMessage, boardName));
            }

            var team = base.Repository.GetTeamByName(teamName);
            var board = base.Repository.CreateBoard(boardName);

            team.AddBoard(board);

            var log = $"Board with name {board.Name} was created and added to team {team.Name}";
            board.LogActivity(log);

            return log;
        }
    }
}