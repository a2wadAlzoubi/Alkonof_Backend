
//using Alkonof_Backend.Application.Common.Interfaces;
//using Alkonof_Backend.Application.Common.Models;
//using Application.Entities.Users.Dtos;

//namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.UpdatePassword
//{
//    public sealed record UpdateUserPasswordCommand(UpdatePasswordDto PasswordDto) : IRequest<bool>;
//}
//internal sealed class CreateTransactionCommandHandler(
//    IApplicationDbContext context,
//    ICurrentUser currentUser) : ICommandHandler<CreateTransactionCommand, Guid>
//{
//    public async Task<Guid> Handle(
//        CreateTransactionCommand request,
//        CancellationToken cancellationToken)
//    {
//        var account = await context.Accounts
//            .FirstOrDefaultAsync(
//                x => x.Id == request.AccountId,
//                cancellationToken);

//        Guard.Against.NotFound(request.AccountId, account);
//        return Result.Failure(err)

//        var userAccount = await context.UserAccounts
//            .FirstOrDefaultAsync(
//                x => x.Id == request.UserAccountId,
//                cancellationToken);

//        Guard.Against.NotFound(request.UserAccountId, userAccount);

//        var user = await context.Users
//            .FirstOrDefaultAsync(
//                x => x.Id == userAccount.UserId,
//                cancellationToken);

//        Guard.Against.NotFound(userAccount.UserId, user);

//        var policy = await context.Policies
//            .FirstOrDefaultAsync(
//                x => x.Id == userAccount.PolicyId,
//                cancellationToken);

//        Guard.Against.NotFound(userAccount.PolicyId, policy);

//        var monthlyAmount =
//            await context.Transactions
//                .Where(...)
//                .SumAsync(...);

//        TransactionBusinessRules.CheckLimit(
//            user,
//            account,
//            policy,
//            monthlyAmount);

//        var transaction = Transaction.Create(
//            ...
//        );

//        account.ApplyTransaction(transaction);

//        context.Transactions.Add(transaction);

//        await context.SaveChangesAsync(cancellationToken);

//        return transaction.Id;
//    }
//}
