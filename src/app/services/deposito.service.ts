import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DepositoService {

  private apiUrl = environment.ApiUrl;

  constructor(private http: HttpClient) { }

  getListaDepositos():Observable<any> {
    return this.http.get(this.apiUrl + '/Deposito');
  }

}
