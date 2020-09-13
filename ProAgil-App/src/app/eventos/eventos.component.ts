import { Component, OnInit } from '@angular/core';
import { Evento } from '../_models/Evento';
import { EventoService } from '../_services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  FiltroLista: string;
  get filtroLista(): string{
    return this.FiltroLista;
  }
  set filtroLista(value: string){
    this.FiltroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  eventosFiltrados: Evento[];
  eventos: Evento[];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;


  constructor(private eventoService: EventoService) { }


  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  // tslint:disable-next-line: typedef
  alterarImagem()
  {
    this.mostrarImagem = !this.mostrarImagem;
  }

  // tslint:disable-next-line: typedef
  getEventos()
  {
    this.eventoService.getAllEvento().subscribe((Eventos: Evento[])  =>
    {
      this.eventos = Eventos;
      this.eventosFiltrados = this.eventos;
      console.log(this.eventos);
    }, error =>
    {
      console.log(error);
    });
  }
}
