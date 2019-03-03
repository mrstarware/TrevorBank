import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'CheckSheet',
  templateUrl: './Check.component.html',
  styleUrls: ['CheckStyle.css']
})
export class CheckComponent implements OnInit {

  sentChecks: Check[];
  checkResponse: Check;
  bankClient: BankClient;


  _http: HttpClient;
  _baseUrl: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
    this.checkResponse = {
      idCheck: 0,
      idCustomer: 0,
      checkNumber: 0,
      payTo: "Hello World",
      dollarAmount: 0,
      memo: "Memo",
      checkDate: new Date(2019, 2, 3)
    };

    this.bankClient = {
      idCustomer: 0,
      firstName: "Trevor",
      middleName: "T",
      lastName: "Tiernan",
      primaryAddress: {
        idAddress: 0,
        zipcode: "97078",
        state: "Oregon",
        city: "Beaverton",
        street: "64789 Street",
        number: "12345 sw",
      },
      //checks: []
    };
  }

  ngOnInit() {
    this._http.get<BankClient>(this._baseUrl + 'api/BankClient/6').subscribe(result => {
      this.bankClient = result;
    }, error => console.error(error));

    this._http.get<BankClient>(this._baseUrl + 'api/BankClient/6').subscribe(result => {
      this.bankClient = result;
    }, error => console.error(error));
  }
}
