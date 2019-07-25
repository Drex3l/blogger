import { Component, ViewChild, ElementRef, EventEmitter, Output, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { DtoAuthorInput, AuthorServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { InputField } from '@app/input-field';

@Component({
    selector: 'create-author-modal',
    templateUrl: './create-author.component.html',
    providers: [AuthorServiceProxy]
})
export class CreateAuthorComponent extends AppComponentBase {
    @ViewChild('createAuthorModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    author: DtoAuthorInput = null;

    constructor(
        injector: Injector,
        private _authorService: AuthorServiceProxy
    ) {
        super(injector);
    }

    show(): void {
        this.active = true;
        this.modal.show();
        this.author = new DtoAuthorInput();
        this.author.init({ isActive: true });
    }
    onShown(): void {
        InputField.txtInput();
    }

    save(): void {
        this.saving = true;

        this._authorService.createAsync(this.author)
            .pipe(finalize(() => { this.saving = false; }))
            .subscribe(() => {
                this.notify.info(this.l('Saved Successfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
