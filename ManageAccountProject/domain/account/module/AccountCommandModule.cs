using ManageAccountProject.database.account.iFace;
using ManageAccountProject.domain.account.model;
using ManageAccountProject.domain.account.model.iFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageAccountProject.domain.account.module
{
    internal class AccountCommandModule
    {

        private IAccountRepository accountRepository;

        public void SaveAccount(IAccount account)
        {
            accountRepository.SaveAccount(account);
        }
    }
}
