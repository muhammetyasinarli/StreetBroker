using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreetBroker
{
    public class RepoCalculator
    {
        private readonly decimal _amount;
        private readonly DateTime _maturity;
        private readonly decimal _interestRate;
        private readonly decimal _taxRate;

        public RepoCalculator(decimal amount, DateTime maturity, decimal intertestRate)
        {
            this._amount = amount;
            this._maturity = maturity;
            this._interestRate = intertestRate;
            this._taxRate = 0.15M;
        }

        public decimal GetTaxRate()
        {
            return _taxRate;
        }
        public decimal GetTaxAmount()
        {
            return _taxRate * GetGrossInterestAmount();
        }
        public decimal GetGrossInterestAmount()
        {
            return _amount * (_maturity - DateTime.Now).Days / DateTime.Now.DayOfYear;
        }
        public decimal GetNetInterestAmount()
        {
            return GetGrossInterestAmount()-GetTaxAmount();
        }
        public decimal GetReturnNetAmount()
        {
            return _amount + GetNetInterestAmount();
        }
        public decimal GetReturnGrossAmount()
        {
            return _amount + GetGrossInterestAmount();
        }
        public DateTime GetMaturityDate()
        {
            return _maturity;
        }
        public DateTime GetStartDate()
        {
            return DateTime.Now;
        }
        public decimal GetAmount()
        {
            return _amount;
        }
        public decimal GetInterestRate()
        {
            return _interestRate;
        }
        public decimal GetGrossInterestRate()
        {
            return _interestRate / (1-_taxRate);
        }
    }
}
