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
        Task<User> ReadCurrUser();
        //public abstract Task<List<Post>> ReadAllPostsFromCurrUser();
        // convert date to timestamp, compare against all posts by curr user
        //public abstract Task<Post> ReadPostByDate(DateTime date);

        // --------------- Update ---------------
        //public abstract Task UpdateUser(User user);
        Task<bool> UpdateLastLogin();
        //public abstract Task UpdatePost(Post post);

        // --------------- Delete ---------------
        //public abstract Task DeleteCurrUser();
        Task<bool> DeleteCurrUserPostAt(DateTime time);
    }
}
