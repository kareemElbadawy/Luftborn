import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { Player } from '../interface/player';

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  private apiURL = environment.apiUrl;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient) { }

  getPlayers(): Observable<Player[]> {
    return this.httpClient.get<Player[]>(this.apiURL + '/Players/GetAllPlayers')
      .pipe(
        catchError(this.errorHandler)
      );
  }

  getPlayer(id:number): Observable<Player> {
    return this.httpClient.get<Player>(this.apiURL + '/players/GetPlayersById/' + id)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  createPlayer(player:any): Observable<Player> {
    return this.httpClient.post<Player>(this.apiURL + '/players/AddPlayers', JSON.stringify(player), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  updatePlayer(id: number, player: any): Observable<Player> {
    return this.httpClient.put<Player>(this.apiURL + '/players/UpdatePlayers', JSON.stringify(player), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  deletePlayer(id:number) {
    return this.httpClient.get<Player>(this.apiURL + '/players/RemovePlayers/' + id, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  errorHandler(error:any) {
    let errorMessage = '';

    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
