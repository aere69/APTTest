import { Component, OnInit } from '@angular/core';
import { ProcessorService } from '../processor.service';
import { SvcResponse } from '../svcresponse';

@Component({
  selector: 'app-process-file',
  templateUrl: './process-file.component.html',
  styleUrls: ['./process-file.component.css']
})
export class ProcessFileComponent implements OnInit {
  selectedFile: any;
  svcResponse = { fileName : '', totalLinesRead : 0 };
  errorMessage = '';
  result = '';

  constructor(private processorService: ProcessorService) {}

  ngOnInit(): void {
  }

  onSubmit() {
    let formData:FormData = new FormData();
    formData.append('file', this.selectedFile, this.selectedFile.name);

    this.processorService.processFile(formData)
      .then(svcResponse => {
        this.svcResponse = svcResponse;
        this.result = 'File Name: ' + this.svcResponse.fileName + ' TotalLinesRead: ' + this.svcResponse.totalLinesRead;
        this.reset();
      },
        error => this.errorMessage = error);
  }

  onSelectFile(event: any) {
    let fileList: FileList = event.target.files;
    if(fileList.length > 0) {
        let file: File = fileList[0];
        this.selectedFile = file;
    }
  }

  private reset() {
    this.errorMessage = '';
    this.svcResponse.fileName = '';
    this.svcResponse.totalLinesRead = 0;
 }
}
