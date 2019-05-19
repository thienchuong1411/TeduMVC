using Models.Framework;
using System.Data.SqlClient;
using System.Linq;

namespace Models
{
    public class UserModel
    {
        // declare variable dbcontext to work with sql
        OnlineShop5DBContext context = null;
        // Constructer
        public UserModel()
        {
            // when new model will create connection
            context = new OnlineShop5DBContext();
        }

        // handle login
        public bool Login(string user, string pass)
        {
            // prepare sql parameters
            object[] sqlParames =
            {
                new SqlParameter("@UserName", user),
                new SqlParameter("@Password", pass)
            };
            var res = 
                context.Database.SqlQuery<bool>("Sp_Account_Login @UserName, @Password", sqlParames).SingleOrDefault();
            return res;
        }
    }
}
