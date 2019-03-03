import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card'; 

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['CheckStyle.css']
})
export class HomeComponent {

  checkResponse: Check;
  Customer: Customer;


  _http: HttpClient;
  _baseUrl: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
    this.checkResponse = {
      idCheck : 0,
      idCustomer : 0,
      checkNumber : 0,
      payTo : "Hello World",
      dollarAmount : 0,
      memo: "Memo",
      checkDate: new Date(2019, 2, 3)
    };

    this.Customer = {
      IdCustomer: 0,
      FirstName: "Trevor",
      MiddleName: "T",
      LastName: "Tiernan",
      PrimaryAddress: {
        IdAddress: 0,
        Zipcode: "97078",
        State: "Oregon",
        City: "Beaverton",
        Street: "187th ave",
        Number : "5378 sw",
      }
    };
  }

  ngOnInit() {
    this._http.get<Check>(this._baseUrl + 'api/Check/3').subscribe(result => {
      this.checkResponse = result;
    }, error => console.error(error));
  }
}
