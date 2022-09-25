using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        //3.213% for a negative balance (balance gets more negative).
        //0.5 % for a positive balance less than 1000 dollars.
        //1.621 % for a positive balance greater than or equal to 1000 dollars and less than 5000 dollars.
        //2.475 % for a positive balance greater than or equal to 5000 dollars.

        if (balance < 0) return 3.213f;
        if (balance < 1000) return 0.5f;
        if (balance < 5000) return 1.621f;
        return 2.475f;
    }

    public static decimal Interest(decimal balance)    
        => (decimal)InterestRate(balance) * balance / 100;   
        
    public static decimal AnnualBalanceUpdate(decimal balance)
        =>(decimal)Interest(balance) + balance;
        

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {        
        int yearsBeforeTarget = 0;

        while (balance < targetBalance)
        {            
            balance = AnnualBalanceUpdate(balance);
            yearsBeforeTarget++;
        }

        return yearsBeforeTarget;        
    }
}
