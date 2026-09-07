import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { Loader } from './components/loader/loader';
import { Sidebar } from './components/sidebar/sidebar';
import { Footer } from './components/footer/footer';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, Loader, Sidebar,Footer],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent implements OnInit {
  isLoading = true;
  onLoadingComplete() {
    this.isLoading = false; 
  }

  ngOnInit() {
    setTimeout(() => {
      this.isLoading = false;
    }, 3000); // 3 ثانية للتحميل
  }
  
}
