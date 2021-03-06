﻿using LightHub.Helper;
using Microsoft.Toolkit.Collections;
using Octokit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LightHub.Model
{
    public class IncrementalLoadSource
    {
        public class CurrentUserPerformedActivitySource : IIncrementalSource<Activity>
        {
            public async Task<IEnumerable<Activity>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
            {
                var result = await Core.GetAllCurrentUserPerformedEvents(new Pagination(pageIndex + 1, pageSize));
                return result;
            }
        }

        public class CurrentUserReceivedActivitySource : IIncrementalSource<Activity>
        {
            public async Task<IEnumerable<Activity>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
            {
                var result = await Core.GetAllCurrentReceivedEvents(new Pagination(pageIndex + 1, pageSize));
                return result;
            }
        }

        public class CurrentUserFollowers : IIncrementalSource<Octokit.User>
        {
            public async Task<IEnumerable<Octokit.User>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
            {
                var result = await Core.GetAllFollowersOfCurrent(new Pagination(pageIndex + 1, pageSize));
                return result;
            }
        }

        public class CurrentUserFollowings : IIncrementalSource<Octokit.User>
        {
            public async Task<IEnumerable<Octokit.User>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
            {
                var result = await Core.GetAllFollowingsOfCurrent(new Pagination(pageIndex + 1, pageSize));
                return result;
            }
        }

        public class UserPerformedActivitySource : IIncrementalSource<Activity>
        {
            private string login { get; set; }

            public UserPerformedActivitySource(string login)
            {
                this.login = login;
            }

            public async Task<IEnumerable<Activity>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
            {
                var result = await Core.GetAllUserPerformedEvents(login, new Pagination(pageIndex + 1, pageSize));
                return result;
            }
        }

        public class UserFollowersSource : IIncrementalSource<Octokit.User>
        {
            private string login { get; set; }

            public UserFollowersSource(string login)
            {
                this.login = login;
            }

            public async Task<IEnumerable<Octokit.User>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
            {
                var result = await Core.GetAllFollowers(login, new Pagination(pageIndex + 1, pageSize));
                return result;
            }
        }

        public class UserFollowingsSource : IIncrementalSource<Octokit.User>
        {
            private string login { get; set; }

            public UserFollowingsSource(string login)
            {
                this.login = login;
            }

            public async Task<IEnumerable<Octokit.User>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
            {
                var result = await Core.GetAllFollowings(login, new Pagination(pageIndex + 1, pageSize));
                return result;
            }
        }
    }
}
