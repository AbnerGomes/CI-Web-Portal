import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
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
  constructor(private depositoService : DepositoService
            , private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getDepositos();
  }

   getDepositos(){
    this.depositoService.getListaDepositos().subscribe(data => {
      
      this.listaDepositos = data;

      console.log(data);
      
    }, error =>{
      console.log(error);
    });
  }


  deleteDeposito(id: number){
    this.depositoService.deleteDeposito(id).subscribe(data => {
      
      this.toastr.error("Deposito deletado com sucesso!");

      console.log(data);
      this.getDepositos();
    }, error =>{
      console.log(error);
      this.toastr.error("Erro: Não foi possível realizar a deleção do deposito selecionado.");
    });
  }

}
