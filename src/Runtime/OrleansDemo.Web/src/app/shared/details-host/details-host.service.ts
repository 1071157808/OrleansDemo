import { Injectable, Type } from '@angular/core';

import { Subject } from 'rxjs/Subject';

export interface DetailsItemComponent {
  data: any;
}

export class DetailsHostItem {
  constructor(public component: Type<DetailsItemComponent>, public data: any) { }
}

@Injectable()
export class DetailsHostService {
  detailsOpen$: Subject<boolean> = new Subject<boolean>();
  currentItem$: Subject<DetailsHostItem> = new Subject<DetailsHostItem>();

  constructor() {
    this.detailsOpen$.next(false);
   }

   openItem(item: DetailsHostItem) {
     this.detailsOpen$.next(true);
     this.currentItem$.next(item);
   }
}