import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'user-entry',
  templateUrl: './userentry.component.html',
  styleUrls: ['userentry.css']
})
export class UserEntryComponent implements OnInit {
  bankClient: BankClient;
  idClient: number;

  _http: HttpClient;
  _baseUrl: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  SubmitUser() {

    var postAddressRoute = this._baseUrl + "api/Address";
    this.bankClient.primaryAddress.idAddress = 0;
    return this._http.post<number>(postAddressRoute, this.bankClient.primaryAddress).subscribe(
      data => {
        var postBankClientRoute = this._baseUrl + "api/BankClient";
        this.bankClient.primaryAddress.idAddress = data;
        this._http.post<number>(postBankClientRoute, this.bankClient).subscribe(
          innerData => {
            this.idClient = innerData;
          }, error => { console.log("Error", error); });
      },
      error => { console.log("Error", error); });
  }

  ngOnInit() {
    this.bankClient = {
      firstName: "",
      lastName: "",
      middleName: "",
      idCustomer: 0,
      primaryAddress: {
        idAddress: 0,
        street: "",
        number: "",
        city: "",
        state: "",
        zipcode: "",
      },
      checks: []
    };
  }

}
