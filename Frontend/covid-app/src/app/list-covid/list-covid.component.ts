import { Component, ViewChild, OnInit } from '@angular/core';
import { HttpServiceService } from '../services/http-service.service'
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

import { Covid } from '../models/covid'

@Component({
  selector: 'app-list-covid',
  templateUrl: './list-covid.component.html',
  styleUrls: ['./list-covid.component.css']
})

export class ListCovidComponent implements OnInit {
  Columns: string[] = ['Country', 'Deaths', 'Cases', 'Confirmed', 'Recovered', 'Updated_at'];

  casos: Covid[] = [];
  dataSource = new MatTableDataSource<Covid>(this.casos);
  constructor(private _httpClient: HttpServiceService) { }

  ngOnInit(): void {
    this.ConsultarCasos();
  }

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  ConsultarCasos() {
    this._httpClient.ObterCasos().subscribe({
      next: result => {
        this.casos = result;
        this.dataSource = new MatTableDataSource<Covid>(this.casos);
        this.dataSource.paginator = this.paginator;
      },
      error: erro => {
        alert('Ocorreu um erro ao buscar os dados');
      }
    });
  }
}
