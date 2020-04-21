import { Component, OnInit } from '@angular/core';
import { SaleService } from '../Service/sale.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sale',
  templateUrl: './sale.component.html',
})
export class SaleComponent implements OnInit {
  sales;

  constructor(private router: Router, private service: SaleService) {
    console.log('1.- Constructor ...')
  }

  ngOnInit() {
    console.log('2.- ngOnInit ...')
    this.service.getListValues().subscribe(
      result => {
        this.sales = result;
        //console.log(this.sales);
      },
      err => {
        console.log(err);
      },
    );
  }
}
