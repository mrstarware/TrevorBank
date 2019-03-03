interface Address {
  idAddress: number;
  zipcode: string;
  state: string;
  city: string;
  street: string;
  number: string;
}

interface BankClient {
  idCustomer: number;
  firstName: string;
  middleName: string;
  lastName: string;
  primaryAddress: Address;
  //checks: Check[];
}

interface Check {
  idCheck: number;
  checkNumber: number;
  idCustomer: number;
  payTo: string;
  dollarAmount: number;
  memo: string;
  checkDate: Date;
}
