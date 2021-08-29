import { Component, OnInit } from '@angular/core';
import * as io from  'socket.io-client';

const SOCKET_ENDPOINT = 'localhost:3000';

@Component({
  selector: 'app-tweet',
  templateUrl: './tweet.component.html',
  styleUrls: ['./tweet.component.css']
})
export class TweetComponent implements OnInit {
  socket;
  public opened: boolean = false;
  constructor() { }

  ngOnInit(): void {
    this.setupConnection();
  }

  setupConnection(){
    this.socket = io.io(SOCKET_ENDPOINT);
    this.socket.on('tweet', tweet => {
      const tweetContainer = document.createElement('div');
      tweetContainer.style.borderBottom = "solid 0.5px gray"
      const textElement = document.createElement('p');
      textElement.innerHTML = tweet.data.text;
      textElement.style.color = "white";
      textElement.style.padding = "5px 10px"

      const dateElement = document.createElement('p');
      dateElement.innerHTML = "Tweeted " + this.parseDateTime(tweet.data.created_at);
      dateElement.style.color = "white";
      dateElement.style.padding = "10px 5px";

      tweetContainer.appendChild(dateElement);
      tweetContainer.appendChild(textElement);
      document.getElementById('tweet').appendChild(tweetContainer);
    });
  }

  openClose(isOpened: boolean){
    this.opened = isOpened;
  }

  private parseDateTime(dateTimeString: string){
    let dateTime = new Date(dateTimeString);
    let day = dateTime.getDate();
    let monthIndex = dateTime.getMonth();
    let year = dateTime.getFullYear();
    let minutes = dateTime.getMinutes();
    let hours = dateTime.getHours();
    return day+"-"+(monthIndex+1)+"-"+year+" "+hours+":"+minutes;
  }

}