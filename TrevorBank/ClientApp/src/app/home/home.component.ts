import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['../Check/CheckStyle.css']
})
export class HomeComponent {

  checkHistory: number[];
  idBankingClient: number = 6;
  isReady: boolean = false;

  _http: HttpClient;
  _baseUrl: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  sortChecks(a: Check, b: Check): number {
    if (a.idCheck < b.idCheck) {
      return -1;
    }
    if (a.idCheck == b.idCheck) {
      return 0;
    }

    return 1;
  }

  lookup() {
    this._http.get<number[]>(this._baseUrl + `api/Check/GetAllSentBy/${this.idBankingClient}`).subscribe(result => {
      this.checkHistory = result;
      this.isReady = true;
    }, error => console.error(error));
  }

  ngOnInit() {
    
  }
}
