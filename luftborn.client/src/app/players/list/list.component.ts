import { Component, OnInit } from '@angular/core';
import { PlayersService } from '../services/players.service';
import { Player } from '../interface/player';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  players: Player[] = [];

  constructor(public playersService: PlayersService) { }

  ngOnInit(): void {
    this.playersService.getPlayers().subscribe((data: Player[]) => {
      console.log(data);
      this.players = data;
    });
  }

  deletePlayer(id:number) {
    this.playersService.deletePlayer(id).subscribe(res => {
      this.players = this.players.filter(item => item.id !== id);
    });
  }
}