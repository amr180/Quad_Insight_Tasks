import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-loader',
  standalone: true,
  imports: [],
  templateUrl: './loader.html',
  styleUrls: ['./loader.css']
})
export class Loader implements OnInit {
  progress = 0;
  statusMessage = 'جاري بدء التشغيل...';

  @Output() loadingComplete = new EventEmitter<void>();

  ngOnInit() {
    this.startProgress();
  }

  startProgress() {
    const interval = setInterval(() => {
      if (this.progress < 100) {
        this.progress += 1;
        this.updateStatus(this.progress);
      } else {
        clearInterval(interval);
        this.statusMessage = 'النظام جاهز';

        setTimeout(() => {
          this.loadingComplete.emit();
        }, 400);
      }
    }, 25);
  }

  updateStatus(val: number) {
    if (val >= 90) this.statusMessage = 'اللمسات الأخيرة...';
    else if (val >= 75) this.statusMessage = 'تجهيز العرض...';
    else if (val >= 50) this.statusMessage = 'معالجة المهام...';
    else if (val >= 20) this.statusMessage = 'جاري تحميل بيانات النظام...';
  }
}