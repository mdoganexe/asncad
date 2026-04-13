import { useQuery } from '@tanstack/react-query'
import { catalogApi } from '../api/services'

interface Props {
  onSelect: (field: string, catalogId: string) => void
  selectedIds?: Record<string, string>
}

const componentFields = [
  { field: 'cabinRailCatalogId', label: 'Kabin Rayı', category: 'ray' },
  { field: 'counterweightRailCatalogId', label: 'Ağırlık Rayı', category: 'ray' },
  { field: 'cabinBufferCatalogId', label: 'Kabin Tamponu', category: 'tampon' },
  { field: 'counterweightBufferCatalogId', label: 'Ağırlık Tamponu', category: 'tampon' },
  { field: 'motorCatalogId', label: 'Motor', category: 'motor' },
  { field: 'safetyDeviceCatalogId', label: 'Fren (Güvenlik)', category: 'fren' },
  { field: 'ropeCatalogId', label: 'Halat', category: 'halat' },
]

export default function ComponentSelector({ onSelect, selectedIds = {} }: Props) {
  return (
    <div className="card" style={{ marginBottom: 24 }}>
      <h2 style={{ marginBottom: 16 }}>Bileşen Seçimi</h2>
      <div className="grid grid-2">
        {componentFields.map(cf => (
          <CatalogDropdown key={cf.field} {...cf} value={selectedIds[cf.field] || ''} onChange={id => onSelect(cf.field, id)} />
        ))}
      </div>
    </div>
  )
}

function CatalogDropdown({ label, category, value, onChange }: {
  field: string; label: string; category: string; value: string; onChange: (id: string) => void
}) {
  const { data: items } = useQuery({
    queryKey: ['catalog', category],
    queryFn: () => catalogApi.getAll(category),
  })

  return (
    <div>
      <label>{label}</label>
      <select value={value} onChange={e => onChange(e.target.value)}>
        <option value="">-- Seçiniz --</option>
        {items?.map(item => (
          <option key={item.id} value={item.id}>{item.modelName}</option>
        ))}
      </select>
    </div>
  )
}
