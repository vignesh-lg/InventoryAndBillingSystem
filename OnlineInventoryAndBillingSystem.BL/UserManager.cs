using System;
using System.Collections.Generic;

using OnlineInventoryAndBillingSystem.Entity;
using OnlineInventoryAndBillingSystem.DAL;
using OnlineInventoryAndBillingSystem.Common;
using System.Data;

namespace OnlineInventoryAndBillingSystem.BL
{
    public class UserManager
    {
        UserRepository userRepository = new UserRepository();
        public static IEnumerable<String> GetDetails()
        {
            return UserRepository.GetDetails();
        }
        public static IEnumerable<String> GetTamilNaduDetails()
        {
            return UserRepository.GetTamilNaduDetails();
        }
        public static IEnumerable<String> GetAndhraDetails()
        {
            return UserRepository.GetAndhraDetails(); ;
        }
        public static IEnumerable<String> GetBangloreDetails()
        {
            return UserRepository.GetBangloreDetails();
        }
        public bool GetCustomerDetails(User user)
        {
            return userRepository.GetCustomerDetails(user);
        }
        public bool ToLogin(User user)
        {
            return userRepository.ToLogin(user);
        }
        public DataTable ToSearch(User user)
        {
            return userRepository.ToSearch(user);
        }
        public DataTable ToBind()
        {
            return userRepository.ToBind();
        }
        public bool UpdateCustomerDetails(User user)
        {
            return userRepository.UpdateCustomerDetails(user);
        }
        public bool DeleteCustomer(User user)
        {
            return userRepository.DeleteCustomer(user);
        }
    }
}
