import { Component, OnDestroy, OnInit } from '@angular/core';
interface StatusStep {
  at: number;
  text: string;
}
@Component({
  selector: 'app-loader',
  imports: [],
  templateUrl: './loader.html',
  styleUrl: './loader.css'
})
export class Loader implements OnInit, OnDestroy {
  isHidden : boolean = false;
  progress = 0;
  statusMessage = 'جاري بدء التشغيل...';

  private intervalId?: ReturnType<typeof setInterval>;
  private finishTimeoutId?: ReturnType<typeof setTimeout>;
  private hideTimeoutId?: ReturnType<typeof setTimeout>;
  private finished = false;

  private readonly statusSteps: StatusStep[] = [
    { at: 20, text: 'جاري تحميل بيانات النظام...' },
    { at: 50, text: 'معالجة المهام...' },
    { at: 75, text: 'تجهيز العرض...' },
    { at: 90, text: 'اللمسات الأخيرة...' }
  ];

  ngOnInit(): void {
    this.intervalId = setInterval(() => {
      if (this.progress < 90) {
        this.progress = Math.min(90, this.progress + Math.floor(Math.random() * 4) + 1);
        this.updateStatusMessage();
      }
    }, 40);

    window.addEventListener('load', this.finishLoading);
    this.finishTimeoutId = setTimeout(this.finishLoading, 5000);
  }

  ngOnDestroy(): void {
    if (this.intervalId) clearInterval(this.intervalId);
    if (this.finishTimeoutId) clearTimeout(this.finishTimeoutId);
    if (this.hideTimeoutId) clearTimeout(this.hideTimeoutId);
    window.removeEventListener('load', this.finishLoading);
  }

  private updateStatusMessage(): void {
    const matchedStep = this.statusSteps.find(
      step => step.at <= this.progress && this.progress < step.at + 25
    );
    if (matchedStep) {
      this.statusMessage = matchedStep.text;
    }
  }

  private readonly finishLoading = (): void => {
    if (this.finished) return;
    this.finished = true;

    if (this.intervalId) clearInterval(this.intervalId);
    if (this.finishTimeoutId) clearTimeout(this.finishTimeoutId);

    this.progress = 100;
    this.statusMessage = 'النظام جاهز';

    this.hideTimeoutId = setTimeout(() => {
      this.isHidden = true;
    }, 500);
  };
}
