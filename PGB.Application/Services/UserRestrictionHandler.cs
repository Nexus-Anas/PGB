﻿using PGB.Application.Interfaces;
using PGB.Application.IRepositories;
using PGB.Domain.Entities;

namespace PGB.Application.Services;

public class UserRestrictionHandler : IUserRestrictionHandler
{
    private readonly IUnitOfWork _uow;
    public UserRestrictionHandler(IUnitOfWork uow) => _uow = uow;




    public async Task<bool> IsUserRestricted(int userId)
    {
        var bannedUser = await _uow.BannedUserRepository.Find(userId);
        return bannedUser is not null;
    }

    public async Task HandleLateReturn(int userId)
    {
        int userPenalties = await _uow.UserPenaltyRepository.CountPenalties(userId);

        if (userPenalties == 0)
            await AddPenaltyAndBanUser(userId);
        else if (userPenalties < Restriction.MaxPenaltyByTrimester)
            await IncrementPenaltyAndCheckLimit(userId);
    }

    private async Task AddPenaltyAndBanUser(int userId)
    {
        var bannedUserInfo = new BannedUserInfo(userId);

        await Task.WhenAll(
            _uow.BannedUserRepository.Ban(new BannedUser(userId)),
            _uow.BannedUserInfoRepository.AddBannedUserInfos(bannedUserInfo),
            _uow.UserPenaltyRepository.AddUserPenalty(new UserPenalty(userId))
        );
    }

    private async Task IncrementPenaltyAndCheckLimit(int userId)
    {
        int userPenaltyValue = await _uow.UserPenaltyRepository.IncrementUserPenalty(userId);

        if (userPenaltyValue == Restriction.MaxPenaltyByTrimester)
        {
            var bannedUserInfo = new BannedUserInfo(userId);
            await Task.WhenAll(
                _uow.BannedUserRepository.Ban(new BannedUser(userId)),
                _uow.BannedUserInfoRepository.AddBannedUserInfos(bannedUserInfo),
                _uow.BannedUserInfoRepository.Update(bannedUserInfo)
            );
        }
    }
}