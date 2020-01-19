import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {StockEntry} from '../../_models/stock.entry';
import {PaginatedResult} from '../../_models/pagination';
import {Article} from '../../_models/article';
import {ArticlesService} from '../../_services/articles.service';
import {AlertifyService} from '../../_services/alertify.service';
import {StockListColumns} from '../../_enums/stock-list-columns.enum';
import {PageChangedEvent} from 'ngx-bootstrap';

@Component({
  selector: 'app-article-check-out',
  templateUrl: './article-check-out.component.html',
  styleUrls: ['./article-check-out.component.css']
})
export class ArticleCheckOutComponent implements OnInit {
  /** Definiert ob die Komponente für den "Geöffnet" modus verwendet wird */
  @Input() forOpenMode: boolean;
  @Input() article: Article;
  @Output() doneOrCanceled = new EventEmitter();
  private actionLabel: string;
  private actionButtonLabel: string;
  private showCols = [StockListColumns.amount, StockListColumns.expireDate, StockListColumns.fillLevel];
  private stockData: PaginatedResult<StockEntry[]>;
  private selectedEntryId: number;

  constructor(private articleData: ArticlesService, private alertify: AlertifyService) {
  }

  ngOnInit() {
    this.LoadData(1);
    this.actionLabel = this.forOpenMode ? 'geöffnet oder verbraucht wurde' : 'ausgebucht werden soll';
    this.actionButtonLabel = this.forOpenMode ? 'Wählen' : 'Ausbuchen';
  }

  pageChanged(args: PageChangedEvent) {
    this.LoadData(args.page);
  }

  private action() {
    if (this.forOpenMode) {

    } else {
      this.checkOut();
    }
  }

  private checkOut() {
    this.articleData.checkOutById(this.selectedEntryId, 1)
      .subscribe(value => {
        this.alertify.success('Artikel Ausgebucht');
        this.doneOrCanceled.emit();
      }, error => {
        this.alertify.error('Ausbuchen fehlgeschlagen: ' + error.message);
      });
  }

  private LoadData(pageNumber: number) {
    this.articleData.getArticleStock(this.article.id, this.article.articleUserSettings.environmentId, pageNumber)
      .subscribe((result: PaginatedResult<StockEntry[]>) => {
        this.stockData = result;
      });
  }
}
