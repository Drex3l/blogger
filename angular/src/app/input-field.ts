export class InputField {
    static txtInput() {
        const ctrls = document.getElementsByClassName('txt-input');

        for (let i = 0 ; i < ctrls.length ; i++) {
            ctrls[i].addEventListener('focus', () => {InputField.focusing(ctrls[i]); });
            ctrls[i].addEventListener('blur', () => {InputField.bluring(ctrls[i]); });
        }
    }
    private static focusing(ctrl) {
        ctrl.parentNode.classList.add('focused');
    }
    private static bluring(ctrl) {
        // tslint:disable-next-line: curly
        if (ctrl.value.toString().trim().length > 0) return;
        ctrl.parentNode.classList.remove('focused');
    }
}
