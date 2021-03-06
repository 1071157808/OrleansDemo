import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

export class DeviceConfig {
  deviceId: string;
  name: string;
  isEnabled: boolean;
  sensors: Array<DeveiceSensorConfig>;
  events: Array<DeviceEventConfig>;

  constructor() {
    this.sensors = new Array<DeveiceSensorConfig>();
    this.events = new Array<DeviceEventConfig>();
  }
}

export class DeveiceSensorConfig {
  deviceSensorId: number;
  sensorId: number;
  name: string;
  isEnabled: boolean;
}

export class DeviceEventConfig {
  deviceEventTypeId: number;
  eventTypeId: number;
  name: string;
  isEnabled: boolean;
}

@Injectable()
export class DeviceService {

  private deviceUri = environment.rootUri + '/api/device';

  constructor(private http: HttpClient) { }

  getDeviceList(): Observable<DeviceConfig[]> {
    return this.http.get<DeviceConfig[]>(this.deviceUri);
  }

  getDevice(deviceId: string): Observable<DeviceConfig> {
    const request = `${this.deviceUri}/${deviceId}`;
    return this.http.get<DeviceConfig>(request);
  }

  save(device: DeviceConfig): Observable<DeviceConfig> {
    return this.http.post<DeviceConfig>(this.deviceUri, device, httpOptions);
  }

  remove(deviceId: string): Observable<{}> {
    const request = `${this.deviceUri}/${deviceId}`;
    return this.http.delete(request);
  }
}
