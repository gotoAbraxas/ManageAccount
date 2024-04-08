using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageAccountProject.domain.account.model.iFace
{
    internal interface IAccount
    {
        long AccountId { get; set; }
        string AccountName { get; set; }
        Guid UserId { get; set; }
        string Amount { get; set; }
    }
}
