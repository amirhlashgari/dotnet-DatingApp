import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private http = inject(HttpClient)
  protected readonly title = signal('Dating App');
  protected members = signal<any>([]);

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/members').subscribe({ // since we are using http request we don't need to unsubscribe, but for custom observables unsubscribe is needed
      next: response => this.members.set(response),
      error: error => console.log(error),
      complete: () => console.log('completed')
    })
  }

  // async ngOnInit() {
  //   this.members.set(await this.getMembers());
  // }

  // async getMembers() {
  //   try {
  //     return lastValueFrom(this.http.get('https://localhost:5001/api/members'));
  //   } catch (err) {
  //     console.log(err);
  //     throw err;
  //   }
  // }
}
