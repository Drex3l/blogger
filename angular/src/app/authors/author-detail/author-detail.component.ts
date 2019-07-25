import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { AuthorDetailOutput, AuthorServiceProxy, EntityDtoOfInt64 } from '@shared/service-proxies/service-proxies';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { UpdateAuthorComponent } from '../update-author/update-author.component';

@Component({
    templateUrl: './author-detail.component.html',
    animations: [appModuleAnimation()],
    providers: [AuthorServiceProxy]
})
export class AthorDetailComponent extends AppComponentBase implements OnInit {

    @ViewChild('updateAuthorModal') updateAuthorModal: UpdateAuthorComponent;

    author: AuthorDetailOutput = new AuthorDetailOutput();
    authorId: number;
    now = new Date(Date.now());

    constructor(
        injector: Injector,
        private _authorService: AuthorServiceProxy,
        private _router: Router,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.authorId = params['authorId'];
            this.loadEvent();
        });
    }

    // Show Modals
    updateAuthor(): void {
        this.updateAuthorModal.show(this.authorId);
    }

    loadEvent() {
        this._authorService.getDetailAsync(this.authorId)
            .subscribe((result: AuthorDetailOutput) => {
                this.author = result;
            });
    }

    deactivateAccount(action: boolean): void {
        // tslint:disable-next-line: prefer-const
        let input = new EntityDtoOfInt64();
        input.id = this.author.id;

        const rm = () => {
            this._authorService.deativateAsync(input)
                  .subscribe(() => {
                    abp.notify.info('Account Deactivated');
                    this.refresh();
                  });
        };
        if (!this.author.isDeactivated) {
            abp.message.confirm(
            'Are you sure you want to deativate this account?',
            (result: boolean) => {
              if (result) {
                rm();
              }
            }
          );
        } else {
            rm();
        }

    }

    backToEventsPage() {
        this._router.navigate(['app/authors']);
    }
    refresh() {
        location.reload();
      }
}
