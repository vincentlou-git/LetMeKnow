using LetMeKnow.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetMeKnow.Interfaces
{
    // Implements CRUD Operations
    public interface IFirebaseDatabaseActor {

        // --------------- Create ---------------
        Task<bool> CreateCurrentUser();
        //public abstract Task CreatePost(Post post);

        // --------------- Read ---------------
        // Equivalent to Search.
        // Any user is allowed to search for usernames
        //public abstract Task<List<User>> ReadAllUsers();
        Task<User> ReadCurrUserInfo();
        // Read from uni database, parameter user (really i just need the email), maybe overload?
        // Student ReadCurrStudentFromUniDatabases(User user);
        //public abstract Task<List<Post>> ReadAllPostsFromCurrUser();
        // convert date to timestamp, compare against all posts by curr user
        //public abstract Task<Post> ReadPostByDate(DateTime date);

        // --------------- Update ---------------
        //public abstract Task UpdateUser(User user);
        Task<bool> UpdateLastLogin();
        Task<bool> UpdateLastLoginOnDisconnect();
        //public abstract Task UpdatePost(Post post);

        // --------------- Delete ---------------
        //public abstract Task DeleteCurrUser();
        bool DeleteCurrUserPostAt(DateTime time);
        bool DeleteCurrUserPostAt(long ticks);
    }
}
