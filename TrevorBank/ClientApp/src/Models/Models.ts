interface Address {
  IdAddress: number;
  Zipcode: string;
  State: string;
  City: string;
  Street: string;
  Number: string;
}

interface Customer {
  IdCustomer: number;
  FirstName: string;
  MiddleName: string;
  LastName: string;
  PrimaryAddress: Address
  //public ICollection < Check > Checks { get; set; }
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
