import { InputField } from './../../input-field';
import { AppComponentBase } from '@shared/app-component-base';
import { ViewChild, ElementRef, EventEmitter, Output, Injector, Component } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { DtoAuthorInput, AuthorServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'update-author-modal',
    templateUrl: './update-author.component.html'
})
export class UpdateAuthorComponent extends AppComponentBase {
    @ViewChild('updateAuthorModal') modal: ModalDirective;
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
    show(authorId?): void {
        this.active = true;
        this.modal.show();
        this.author = new DtoAuthorInput();
        this.author.init({ isActive: true });

        this._authorService.getDetailAsync(authorId)
            .subscribe((result: DtoAuthorInput) => {
                this.author = result;
            });
    }
    onShown(): void {
        InputField.txtInput();
    }
    save(): void {
        this.saving = true;
        this._authorService.updateAsync(this.author)
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
