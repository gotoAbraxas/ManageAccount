using ManageAccountProject.database.account.iFace;
using ManageAccountProject.domain.account.model;
using ManageAccountProject.domain.account.model.iFace;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageAccountProject.database.account
{
    internal class AccountRepositoryInMemory
    {

        #region "생성자, 싱글톤 구현"
        private AccountRepositoryInMemory()
        {

            #if DEBUG
            TestInit();
            #endif
        }
        private AccountRepositoryInMemory Repository { get; set; }

        private static class SingletonHelper
        {
            internal static AccountRepositoryInMemory INSTANCE { get; } = new AccountRepositoryInMemory();
        }

        public static AccountRepositoryInMemory GetInstance()
        {
            return SingletonHelper.INSTANCE;
        }
        #endregion

        #region "속성"
        public static Dictionary<long, IAccount> Accounts = new Dictionary<long, IAccount>();
        #endregion


        private void TestInit()
        {

            // 
            /*
            string json = File.ReadAllText("test.json", Encoding.UTF8);
            // JSON 문자열을 C# 객체의 리스트로 역직렬화
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(json);

            foreach (Account item in accounts)
            {
                SaveAccount(item);
            }

            */
        }

        #region "메서드"
        public IAccount GetAccountById(Guid userId, long accountId)
        {
            try
            {
                return Accounts.Where(account => account.Value.UserId == userId && account.Value.AccountId == accountId).Single().Value;
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("유저코드와 계좌코드가 전달이 안되었을 때.");
                return new Account();
            }
            catch (Exception e)
            {
                MessageBox.Show("해당 계좌가 존재하지않음.");
                return new Account();
            }
        }

        public List<IAccount> GetAccountsByIds(Guid userCode, List<long> accountIds)
        {
            try
            {
                return Accounts
                    .Where(account => account.Value.UserId == userCode && accountIds.Contains(account.Value.AccountId))
                    .Select((item) => item.Value)
                    .ToList();
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("유저코드와 계좌코드가 전달이 안되었을 때.");
                return new List<IAccount> { new Account() };
            }
        }

        public Dictionary<long, IAccount> GetAllAccountsById(Guid userId)
        {

            try
            {
                return Accounts
                .Where(account => account.Value.UserId == userId)
                .ToDictionary(account => account.Value.AccountId, account => account.Value);

            }
            catch (ArgumentException e)
            {
                MessageBox.Show("유저코드가 전달이 안되었을 때.");
                return new Dictionary<long, IAccount>();
            }
        }
        /*
        public Dictionary<long, IAccount> GetAllAccountsByIdWithCondition(long userCode, SearchCondition condition)
        {
            try
            {
                return Accounts
                .Where(account => account.Value.UserCode == userCode)
                .Where(account => condition.LowerInterest is null || account.Value.Interest > condition.LowerInterest)
                .Where(account => condition.PeriodCondition ? account.Value.PeriodConditions.Count > 0 : true)
                .Where(account => condition.AmountCondition ? account.Value.AmountConditions.Count > 0 : true)
                .Where(account => condition.Protected ? account.Value.ProtectAccount : true)
                .Where(account => condition.UpperLimit ? account.Value.CheckUpperLimitWellInterest : true)
                .Where(account => condition.LimitInterestDate is null || CheckInterestDate(condition, account))
                .OrderByDescending(account => condition.IsOrderedGenerally ? account.Value.Interest : MaxInterest(account.Value))
                .ToDictionary(account => account.Value.AccountId, account => account.Value);

            }
            catch (ArgumentException e)
            {
                MessageBox.Show("유저코드가 전달이 안되었을 때.");
                return new Dictionary<long, IAccount>();
            }
        }
        */



        public void SaveAccount(IAccount account)
        {

            Accounts.Add(account.AccountId, account);
        }
    }


    #endregion
}
