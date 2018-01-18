#include <iostream>

using namespace std;

class BankAccount
{
public:
	bool withdraw(float sum);
	void deposit(float sum);

private:
	float currentBalance = 0;
};

bool BankAccount::withdraw(float sum)
{
	if (currentBalance >= sum)
	{
		currentBalance -= sum;
		return true;
	}
	return false;
}

void BankAccount::deposit(float sum)
{
	currentBalance += sum;
}

int main()
{
	BankAccount myBankAccount;
	myBankAccount.deposit(10);
	
	//PayPal requests $7
	float requestedMoney = 7;
	if (myBankAccount.withdraw(requestedMoney))
	{
		cout << "You have payed " << requestedMoney << endl;
	}
	else
	{
		cout << "Unable to withdraw " << requestedMoney << endl;
	}
	return 0;
}