using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.OrmLite;

namespace Data
{
    class UserTokenRelationRepository : DataItemRepository<UserTokenRelation>
    {
        public UserTokenRelation GetUserRecord(int uid, int sid)
        {
            using (var dbConn = DbFactory.OpenDbConnection())
            using (var dbCmd = dbConn.CreateCommand())
            {
                return dbCmd.FirstOrDefault<UserTokenRelation>(record => record.Uid == uid
                                                                       && record.Sid == sid);
            }
        }
    }
}
