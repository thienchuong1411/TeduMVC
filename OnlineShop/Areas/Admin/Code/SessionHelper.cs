using System.Web;

namespace OnlineShop.Areas.Admin.Code
{
    public class SessionHelper
    {
        // set if user login success
        public static void SetSession(UserSession session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }

        // get session, use when end user access page and it will check session of user
        public static UserSession GetSession()
        {
            var session = HttpContext.Current.Session["loginSession"];

            // check session is null or not?
            if (session == null)
            {
                return null;
            }
            else
            {
                // thực tế trên máy tính có chưa session nhưng nó sẽ ko biết session đó có kiểu là gì
                // khi ta return ta chuyển kiểu hay define session này có kiểu là UserSession
                return session as UserSession;  
            }
        }
    }
}