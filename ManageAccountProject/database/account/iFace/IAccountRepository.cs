using ManageAccountProject.domain.account.model;
using ManageAccountProject.domain.account.model.iFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageAccountProject.database.account.iFace
{
    internal interface IAccountRepository
    {

        IAccount GetAccountById(long userCode, long AccountCode);
        Dictionary<long, IAccount> GetAllAccountsById(long userCode);
        void SaveAccount(IAccount account);
        List<IAccount> GetAccountsByIds(long userCode, List<long> accountCodes);

    }
}
