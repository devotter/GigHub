﻿using GigHub.Models;
using System.Linq;

namespace GigHub.Repositories
{
    public class FollowingRepository
    {
        private readonly ApplicationDbContext _context;
        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string followeeId, string followerId)
        {
            return _context.Followings
                    .SingleOrDefault(f => f.FolloweeId == followeeId && f.FollowerId == followerId);
        }
    }
}