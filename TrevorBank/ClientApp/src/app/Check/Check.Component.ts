import { Component, Inject, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'CheckSheet',
  templateUrl: './Check.component.html',
  styleUrls: ['CheckStyle.css']
})
export class CheckComponent implements OnInit {

  @Input() idBankingClient: number;

  @Input() active: boolean;

  @Input() idCheck: number;

  @Output() reloadChecks = new EventEmitter<boolean>();

  sentChecks: Check[];
  freshCheck: Check;
  checkResponse: Check;
  bankClient: BankClient;

  _http: HttpClient;
  _baseUrl: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;

    this.bankClient = {
      firstName: "Loading",
      lastName: "Loading",
      middleName: "Loading",
      idCustomer : -1,
      primaryAddress : {
        idAddress : -1,
        street : "Loading",
        number : "Loading",
        city : "Loading",
        state : "Loading",
        zipcode : "00000",
      },
      checks : []
    };

    this.freshCheck = {
      idCheck: 0,
      idCustomer: 0,
      checkNumber: 0,
      payTo: "",
      dollarAmount: 0,
      memo: "",
      checkDate: new Date()
    };
  }

  sortChecks(a: Check, b: Check): number {
    if (a.idCheck < b.idCheck) {
      return -1;
    }
    if (a.idCheck == b.idCheck)
    {
      return 0;
    }

    return 1;
  }

  ngOnInit() {

    this._http.get<BankClient>(this._baseUrl + `api/BankClient/${this.idBankingClient}`).subscribe(result => {
      this.bankClient = result;
      if (this.idCheck == -1) {
        let lastCheckNumber: number = 0;
        if (this.bankClient.checks.length > 0) {
          //this.bankClient.checks.sort(this.sortChecks);
          lastCheckNumber = this.bankClient.checks[this.bankClient.checks.length - 1].checkNumber;
        }
        this.freshCheck.checkNumber = lastCheckNumber + 1;
      }
      else {
        this.idCheck;
        this._http.get<Check>(this._baseUrl + `api/Check/${this.idCheck}`).subscribe(result => {
          this.freshCheck = result;
        }, error => console.error(error));
      }
    }, error => console.error(error));
  }

  sendCheck() {
    var sendCheckUrl = this._baseUrl + "api/Check";
    var checkToSend: Check = {
      checkNumber: this.freshCheck.checkNumber,
      idCustomer: this.bankClient.idCustomer,
      payTo: this.freshCheck.payTo,
      dollarAmount: this.freshCheck.dollarAmount,
      memo: this.freshCheck.memo,
      checkDate: this.freshCheck.checkDate,
    };

    return this._http.post<Check>(sendCheckUrl, checkToSend).subscribe(
      data => {
        console.log("POST Request is successful ", data);
        this.reloadChecks.emit(true);
      },
      error => { console.log("Error", error); });
  }
}
