/* =========================================================
   Quad Insight - Global Loading Page Logic (Shared)
   IIFE Pattern لمنع تلوث الـ Global Scope
   ========================================================= */
(function () {
    document.addEventListener('DOMContentLoaded', function () {
        var loader = document.getElementById('global-loader');
        if (!loader) return;

        var progressFill = document.getElementById('progressFill');
        var percentageIndicator = document.getElementById('percentageIndicator');
        var statusMessage = document.getElementById('statusMessage');

        var progress = 0;
        var statusSteps = [
            { at: 20, text: 'جاري تحميل بيانات النظام...' },
            { at: 50, text: 'معالجة المهام...' },
            { at: 75, text: 'تجهيز العرض...' },
            { at: 90, text: 'اللمسات الأخيرة...' }
        ];

        var interval = setInterval(function () {
            if (progress < 90) {
                progress += Math.floor(Math.random() * 4) + 1;
                if (progress > 90) progress = 90;
                updateUI(progress);
            }
        }, 40);

        function updateUI(val) {
            progressFill.style.width = val + '%';
            percentageIndicator.innerText = val + '%';

            var matchedStep = statusSteps.find(function (step) {
                return step.at <= val && val < step.at + 25;
            });
            if (matchedStep) {
                statusMessage.innerText = matchedStep.text;
            }
        }

        function finishLoading() {
            clearInterval(interval);
            updateUI(100);
            statusMessage.innerText = 'النظام جاهز';

            setTimeout(function () {
                loader.classList.add('hidden');
            }, 500);
        }

        // الاختفاء الفعلي مرتبط بحدث تحميل الصفحة الحقيقي وليس مؤقّت وهمي
        window.addEventListener('load', finishLoading);

        // خط أمان: 5 ثواني كحد أقصى في حال بطء الشبكة
        setTimeout(finishLoading, 5000);
    });
})();
