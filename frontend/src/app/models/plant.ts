export interface Plant {
  id: number;
  name?: string;
  description?: string;
  imageUrl?: string;
  scientificName?: string;
  family?: string;
  genus?: string;
  species?: string;
  commonName?: string;
  careInstructions?: string;
  isIndoor: boolean;
  isOutdoor: boolean;
  isPerennial: boolean;
  isAnnual: boolean;
}

export interface PlantDto {
  name?: string;
  description?: string;
  imageUrl?: string;
  scientificName?: string;
  family?: string;
  genus?: string;
  species?: string;
  commonName?: string;
  careInstructions?: string;
  isIndoor: boolean;
  isOutdoor: boolean;
  isPerennial: boolean;
  isAnnual: boolean;
} 