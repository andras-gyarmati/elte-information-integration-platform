import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { environment } from '../../environments/environment';
import { PagedListResult, Result } from '../common/result';

export interface IApiService {
}

@Injectable({
  providedIn: 'root'
})
export abstract class ApiService<T> implements IApiService {
  protected constructor(protected httpClient: HttpClient) {
  }

  public abstract getPath(): string;

  async getPagedList(filter: string, page: number, pageResults: number, postfix: string = ''): Promise<PagedListResult<T> | undefined> {
    postfix = postfix.length > 0 ? `/${postfix}` : '';
    return await lastValueFrom(this.httpClient.get<PagedListResult<T>>(`${environment.apiUrl}/${this.getPath()}${postfix}`, {
      headers: {
        Filtering: filter
      },
      params: {
        Page: page,
        PageResults: pageResults
      }
    }));
  }

  async get(id: any): Promise<Result<T> | undefined> {
    return await lastValueFrom(this.httpClient.get<Result<T>>(`${environment.apiUrl}/${this.getPath()}/${id}`, {}));
  }

  async delete(id: any): Promise<Result<number> | undefined> {
    return await lastValueFrom(this.httpClient.delete<Result<number>>(`${environment.apiUrl}/${this.getPath()}/${id}`, {}));
  }

  public async create<U>(entry: U): Promise<any> {
    return await lastValueFrom(this.httpClient.post<U>(`${environment.apiUrl}/${this.getPath()}`, entry, {}));
  }

  public async update<U>(id: any, entry: U): Promise<any> {
    return await lastValueFrom(this.httpClient.patch<U>(`${environment.apiUrl}/${this.getPath()}/${id}`, entry, {}));
  }

  async uploadFile(file: File, sheetName: string | null = null, path: string = ''): Promise<any> {
    const formData = new FormData();
    formData.append('files', file);
    if (sheetName) {
      formData.append('sheetName', sheetName);
    }
    return await lastValueFrom(this.httpClient.post(`${environment.apiUrl}/${this.getPath()}/${path}/import`, formData, {}));
  }

  protected download(filename: string, href: string): void {
    const pom = document.createElement('a');
    pom.setAttribute('href', href);
    pom.setAttribute('download', filename);
    if (document.createEvent) {
      const event = document.createEvent('MouseEvents');
      event.initEvent('click', true, true);
      pom.dispatchEvent(event);
    } else {
      pom.click();
    }
  }
}
