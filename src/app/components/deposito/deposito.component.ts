import { Component, OnInit } from '@angular/core';
import { DepositoService } from 'src/app/services/deposito.service';

@Component({
  selector: 'app-deposito',
  templateUrl: './deposito.component.html',
  styleUrls: ['./deposito.component.css']
})
export class DepositoComponent implements OnInit {

  listacartoes : any[] = [
    {titular: 'Abner Gomes', data: '11/23', codigo: '999'},
    {titular: 'William Oliveira', data: '11/24', codigo: '111'},
  ];

  listaDepositos: any[] = [];

  constructor(private depositoService : DepositoService) { }

  ngOnInit(): void {
    this.retornacartoes();
  }

  retornacartoes(){
    this.depositoService.getListaDepositos().subscribe(data => {
      
      this.listaDepositos = data;

      console.log(data);
    }, error =>{
      console.log(error);
    });
  }


}
