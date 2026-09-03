import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { Loader } from './components/loader/loader';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, Loader],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent implements OnInit {
  isLoading = true;
  onLoadingComplete() {
    this.isLoading = false; // هنا يتم إخفاء اللودر وإظهار محتوى الصفحة
  }

  ngOnInit() {
    // محاكاة انتهاء التحميل بعد فترة (أو يمكنك التحكم بها عبر Service)
    setTimeout(() => {
      this.isLoading = false;
    }, 2500); // 2.5 ثانية للتحميل
  }
  
}
