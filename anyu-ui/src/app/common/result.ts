export class Result<T> {
  constructor(public value: T, public errorMessage: string) {
  }

  public hasValue(): boolean {
    return this.value != null;
  }

  public hasError(): boolean {
    return this.errorMessage != null;
  }
}

export class PagedListResult<T> {
  constructor(public value: T[] = [],
              public errorMessage: string | null,
              public currentPage: number,
              public currentPageResults: number,
              public totalPages: number,
              public totalResults: number) {
  }
}

export class ListResult<T> {
  constructor(public value: T[] = [], public totalResults: number) {
  }
}
