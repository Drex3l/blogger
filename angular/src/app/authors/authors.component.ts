import { AppComponentBase } from 'shared/app-component-base';
import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CreateAuthorComponent } from './create-author/create-author.component';
import { AuthorListDto, AuthorServiceProxy } from '@shared/service-proxies/service-proxies';
import { PagedRequestDto } from '@shared/paged-listing-component-base';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  animations: [appModuleAnimation()],
  providers: [AuthorServiceProxy]
})
export class AuthorsComponent extends AppComponentBase implements OnInit {
  @ViewChild('createAuthorModal') createAuthorModal: CreateAuthorComponent;

  active: boolean = false;
  authors: AuthorListDto[] = [];
  IncludeInactiveAccounts: boolean = false;

  constructor(
    injector: Injector,
    private _authorService: AuthorServiceProxy
  ) {
    super(injector);
  }

  ngOnInit() {
    this.loadEvent();
  }
  IncludeInactiveAccountsCheckboxChanged() {
    this.loadEvent();
  }

  // Show Modals
  createAuthor(): void {
    this.createAuthorModal.show();
  }
  refresh() {
    location.reload();
  }
  loadEvent() {
    this._authorService.getListAsync(this.IncludeInactiveAccounts)
      .subscribe((result) => {
        this.authors = result.items;
      });
  }

}
