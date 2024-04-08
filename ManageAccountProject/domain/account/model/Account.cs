using ManageAccountProject.domain.account.model.iFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageAccountProject.domain.account.model
{
    internal class Account : IAccount
    {
        public string AccountName { get; set; }
        public long AccountId { get; set; }
        public string Amount { get; set; }
        public Guid UserId { get; set; }
    }
}
